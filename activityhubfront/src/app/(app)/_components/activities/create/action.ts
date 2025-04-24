"use server";
import { createActivity } from "@/http/activities/create";
import { console } from "inspector";
import { HTTPError } from "ky";
import { z } from "zod";

const CreateActvitySchema = z.object({
  title: z.string().min(2, { message: "Título não pode estar vazio." }),
  description: z
    .string()
    .min(2, { message: "Por gentiliza forneça uma breve descrição." }),
});

export type CreateActvitySchema = z.infer<typeof CreateActvitySchema>;

export default async function createActivityAction(data: FormData) {
  const result = CreateActvitySchema.safeParse(Object.fromEntries(data));

  if (!result.success) {
    const errors = result.error.flatten().fieldErrors;
    return { success: false, message: null, errors };
  }

  const { title, description } = result.data;

  try {
    await createActivity({ title, description });
  } catch (err) {
    if (err instanceof HTTPError) {
      const { message } = await err.response.json();
      return { success: false, message, errors: null };
    }
    console.log(err);
    return {
      success: false,
      message: "Unexpected error, try again in a few minutes.",
      errors: null,
    };
  }
  return { success: true, message: null, errors: null };
}
