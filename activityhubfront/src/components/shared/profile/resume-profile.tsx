import { auth } from "@/auth/auth";
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar";
import { Button } from "@/components/ui/button";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Separator } from "@/components/ui/separator";
import { Mail, LogOut } from "lucide-react";

export default async function ResumeProfile() {
  const { user } = await auth();
  console.log(user);
  return (
    <Card>
      <CardHeader className="flex flex-col items-center text-center">
        <div className="relative mb-4">
          <Avatar className="h-24 w-24 border-4">
            <AvatarImage src={user.avatar_url} alt={user.name} />
            <AvatarFallback className="text-xl text-accent">
              {user.name
                .split(" ")
                .map((n) => n[0])
                .join("")}
            </AvatarFallback>
          </Avatar>
          {/* {!isEditing && (
              <Button
                size="icon"
                className="absolute bottom-0 right-0 h-8 w-8 rounded-full bg-blue-medium hover:bg-blue-dark text-white"
                onClick={() => setIsEditing(true)}
              >
                <Edit className="h-4 w-4" />
              </Button>
            )} */}
        </div>
        <CardTitle className="text-xl">{user.name}</CardTitle>
      </CardHeader>
      <CardContent className="space-y-4">
        <div className="flex items-center gap-2">
          <Mail className="h-4 w-4" />
          <span className="text-sm">{user.email}</span>
        </div>
        <Separator className="my-4" />
        <div className="grid grid-cols-2 gap-4 text-center">
          <div>
            <p className="text-2xl font-bold">30</p>
            <p className="text-xs">Tasks Completed</p>
          </div>
        </div>
        <Button variant="outline" className="w-full">
          <LogOut className="mr-2 h-4 w-4" />
          Sign Out
        </Button>
      </CardContent>
    </Card>
  );
}
