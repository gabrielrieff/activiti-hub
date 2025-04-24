import { ActivityStatus } from "@/communication/responses/enum/ActivityStatus";
import { api } from "../api-client";

interface createActivityRequest {
  title: string;
  description: string;
}

export interface createActivityResponse {
  title: string;
  description: string;
  status: ActivityStatus;
}

export async function createActivity({
  title,
  description,
}: createActivityRequest) {
  const result = await api
    .post("Activity/Register", {
      json: {
        title,
        description,
      },
    })
    .json<createActivityResponse>();

  return result;
}
