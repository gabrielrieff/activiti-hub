"use server";

import { redirect } from "next/navigation";

export async function SignInWithGithub() {
  const githubSignInUrl = new URL(
    "login/oauth/authorize",
    "https://github.com"
  );

  githubSignInUrl.searchParams.set("client_id", "Ov23liU56GOHLIyLifnt");
  githubSignInUrl.searchParams.set(
    "redirect_uri",
    "http://localhost:3000/api/auth/callback"
  );
  githubSignInUrl.searchParams.set("soce", "user");

  redirect(githubSignInUrl.toString());
}
