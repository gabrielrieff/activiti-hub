import { deleteActivity } from "@/http/activities/deleteAct";
import { clsx, type ClassValue } from "clsx";
import { twMerge } from "tailwind-merge";
import { queryClient } from "./react-query";

export function cn(...inputs: ClassValue[]) {
  return twMerge(clsx(inputs));
}

export async function deleteAct(id: string) {
  await deleteActivity({ id });

  queryClient.invalidateQueries({
    queryKey: ["activities"],
  });
}
