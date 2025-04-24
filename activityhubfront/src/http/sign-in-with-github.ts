import { api } from "./api-client";

interface signInWithGithubRequest {
  code: string;
}

interface signInWithGithubResponse {
  token: string;
}

export async function signInWithGithub({ code }: signInWithGithubRequest) {
  const result = await api
    .post("Auth/login-github", {
      json: { code },
    })
    .json<signInWithGithubResponse>();

  return result;
}
