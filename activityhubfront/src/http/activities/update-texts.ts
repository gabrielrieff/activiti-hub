import { api } from "../api-client";

interface updateTextsActivityRequest {
  id: string;
  title: string;
  description: string;
}

export async function updateTextsActivity({
  id,
  title,
  description,
}: updateTextsActivityRequest) {
  const result = await api.put(`Activity/${id}/update-text`, {
    json: {
      title,
      description,
    },
  });

  return result;
}
