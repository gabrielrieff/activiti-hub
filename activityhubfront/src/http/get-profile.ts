import { api } from "./api-client";

interface getProfileResponse {
  name: string;
  email: string;
  avatar_url: string;
}

export async function getProfile() {
  const result = await api.get("User").json<getProfileResponse>();
  return result;
}
