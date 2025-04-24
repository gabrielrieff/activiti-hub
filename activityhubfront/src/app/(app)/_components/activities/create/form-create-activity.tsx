"use client";

import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Textarea } from "@/components/ui/textarea";
import createActivityAction from "./action";
import { useFormState } from "@/hooks/use-form-state";
import { Loader2 } from "lucide-react";

export default function FormCreateActivity() {
  const [{ errors }, handleSubmit, isPending] = useFormState(
    createActivityAction,
    () => {}
  );

  return (
    <div className="space-y-4">
      <form onSubmit={handleSubmit} className="space-y-4">
        <div className="space-y-1">
          <Label htmlFor="title">Título</Label>
          <Input id="title" name="title" type="text" />
          {errors?.title && (
            <span className="text-xs font-medium text-red-500 dark:text-red-400">
              {errors.title[0]}
            </span>
          )}
        </div>
        <div className="space-y-1">
          <Label htmlFor="description">Descrição</Label>
          <Textarea id="description" name="description" />
          {errors?.description && (
            <span className="text-xs font-medium text-red-500 dark:text-red-400">
              {errors.description[0]}
            </span>
          )}
        </div>

        <Button className="w-full">
          {isPending ? <Loader2 className="size-4 animate-spin" /> : "Salvar"}
        </Button>
      </form>
    </div>
  );
}
