import { cn } from "@/lib/utils";
import Link from "next/link";

type buttonActiveProps = {
  children: React.ReactNode;
  className?: string;
  href: string;
  active?: boolean;
};

export function ButtonActive({
  className,
  children,
  href,
  active,
}: buttonActiveProps) {
  return (
    <Link
      href={href}
      className={cn([
        "text-sm px-3 py-2 rounded-md flex items-center text-white hover:bg-purple-600 transition-[1s]",
        active && "bg-secondary font-medium",
        className,
      ])}
    >
      {children}
    </Link>
  );
}
