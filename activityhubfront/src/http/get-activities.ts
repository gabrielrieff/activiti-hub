import { Activity } from "@/communication/responses/@types/Activity";
import { api } from "./api-client";

export interface getActivitiesResponse {
  id: string;
  title: string;
  listActivities: Activity[];
}

export async function getActivities(
  month: number = new Date().getMonth() + 1,
  year: number = new Date().getFullYear()
) {
  const result = await api
    .get(`Activity?month=${month}&year=${year}`)
    .json<getActivitiesResponse[]>();

  await new Promise((resolve) => setTimeout(resolve, 3000));
  return result;
}
