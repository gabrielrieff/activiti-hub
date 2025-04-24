import { isAuthenticated } from "@/auth/auth";
import { Header } from "@/components/shared/header";
import { Toaster } from "@/components/ui/sonner";
import { redirect } from "next/navigation";

export default async function AppLayout({
  children,
  modal,
}: Readonly<{
  children: React.ReactNode;
  modal: React.ReactNode;
}>) {
  if (await !isAuthenticated()) {
    redirect("/auth/sign-in");
  }

  return (
    <>
      <div className="min-h-screen bg-primary flex flex-col relative">
        <Header />
        {children}
        {modal}
        <Toaster />
      </div>
    </>
  );
}
