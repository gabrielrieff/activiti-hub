import { api } from "../api-client";

interface deleteActivityRequest {
  id: string;
}

export async function deleteActivity({ id }: deleteActivityRequest) {
  await api.delete(`Activity/${id}`);
}
