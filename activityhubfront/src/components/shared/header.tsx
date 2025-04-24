import { Zap } from "lucide-react";
import DropdownProfile from "./dropdown-profile";
import { NotificationComp } from "./notification-comp";
import Link from "next/link";

export function Header() {
  return (
    <header className="w-full flex xl:px-32 px-6 justify-center sticky top-0 z-10 bg-secondary text-neutral-300">
      <div className="w-full flex h-16 items-center justify-between">
        <Link href="/" className="flex items-center gap-2 font-medium">
          <Zap className="!w-6 !h-6 text-purple-500" />
          <span className="text-lg font-semibold">ActHub</span>
        </Link>
        <div className="flex items-center gap-4">
          <NotificationComp />
          <DropdownProfile />
        </div>
      </div>
    </header>
  );
}
