import { api } from "../api-client";

interface updateStatusActivityRequest {
  id: string;
  status: number;
}

export async function updateStatusActivity({
  id,
  status,
}: updateStatusActivityRequest) {
  await api.put(`Activity/${id}/update-status`, {
    json: {
      status,
    },
  });
}
