"use client";

import { ButtonActive } from "@/components/shared/button-active";
import { usePathname } from "next/navigation";

export default function ProfileLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
  modal: React.ReactNode;
}>) {
  const pathname = usePathname();

  const isActive = (path: string) => {
    return pathname === path;
  };
  return (
    <div className="flex justify-center py-6 px-4">
      <main className="w-full">
        <div className="grid gap-8 grid-cols-4">
          <div className="flex flex-col gap-2">
            <ButtonActive href="/profile" active={isActive("/profile")}>
              Profile
            </ButtonActive>
            <ButtonActive href="/settings" active={isActive("/settings")}>
              Setting
            </ButtonActive>
          </div>
          <div className="col-span-3">{children}</div>
        </div>
      </main>
    </div>
  );
}
