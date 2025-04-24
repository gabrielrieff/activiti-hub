import {
  NavigationMenu,
  NavigationMenuItem,
  NavigationMenuList,
} from "@/components/ui/navigation-menu";
import Link from "next/link";
import { Button } from "../ui/button";

export function MenuNavegation() {
  return (
    <NavigationMenu className="mx-auto flex max-w-[1200px] items-center justify-end  py-4">
      <NavigationMenuList>
        <NavigationMenuItem>
          <NavigationMenuItem asChild>
            <Button>
              <Link href="/activity/create" legacyBehavior passHref>
                Criar
              </Link>
            </Button>
          </NavigationMenuItem>{" "}
        </NavigationMenuItem>
      </NavigationMenuList>
    </NavigationMenu>
  );
}
