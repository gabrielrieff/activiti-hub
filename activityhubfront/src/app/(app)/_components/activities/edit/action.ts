"use server";
import { updateTextsActivity } from "@/http/activities/update-texts";
import { console } from "inspector";
import { HTTPError } from "ky";
import { z } from "zod";

const UpdateTextsActvitySchema = z.object({
  id: z.string(),
  title: z.string().min(2, { message: "Título não pode estar vazio." }),
  description: z
    .string()
    .min(2, { message: "Por gentiliza forneça uma breve descrição." }),
});

export type UpdateTextsActvitySchema = z.infer<typeof UpdateTextsActvitySchema>;

export default async function updateTextsActivityAction(data: FormData) {
  const result = UpdateTextsActvitySchema.safeParse(Object.fromEntries(data));

  if (!result.success) {
    const errors = result.error.flatten().fieldErrors;
    return { success: false, message: null, errors };
  }

  const { title, description, id } = result.data;

  try {
    await updateTextsActivity({ id, title, description });
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
