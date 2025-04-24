import { Button } from "@/components/ui/button";
import { Github } from "lucide-react";
import { SignInWithGithub } from "./actions";

export default function SignInPage() {
  return (
    <form
      action={SignInWithGithub}
      className="space-y-4 flex flex-col justify-center"
    >
      <h1 className="mt-10 scroll-m-20 border-b pb-2 text-3xl font-semibold tracking-tight transition-colors first:mt-0">
        Login by Github
      </h1>
      <Button variant="default">
        <Github className="size-5" />
        Sign in with Github
      </Button>
    </form>
  );
}
