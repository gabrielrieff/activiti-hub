import { ActivityStatus } from "@/communication/responses/enum/ActivityStatus";
import { api } from "../api-client";

export interface getByIdActivityResponse {
  title: string;
  description: string;
  status: ActivityStatus;
}

export async function getByIdActivity(id: string) {
  const result = await api
    .get(`Activity/${id}`)
    .json<getByIdActivityResponse>();

  return result;
}
