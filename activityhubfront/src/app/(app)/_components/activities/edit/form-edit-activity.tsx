"use client";

import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Textarea } from "@/components/ui/textarea";
import { useFormState } from "@/hooks/use-form-state";
import { Save, Trash2 } from "lucide-react";
import { getByIdActivityResponse } from "@/http/activities/get-by-id";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import { ActivityStatusLabel } from "@/communication/responses/enum/ActivityStatus";
import updateTextsActivityAction from "./action";
import { updateStatusActivity } from "@/http/activities/update-status";
import { queryClient } from "@/lib/react-query";
import { deleteAct } from "@/lib/utils";

interface FormEditActivityProps {
  id: string;
  activity: getByIdActivityResponse;
}

export default function FormEditActivity({
  activity,
  id,
}: FormEditActivityProps) {
  const [{ errors }, handleSubmit, isPending] = useFormState(
    updateTextsActivityAction,
    () => {}
  );

  async function updateStatus(value: string) {
    await updateStatusActivity({ id: id, status: Number(value) });
    console.log("teste");
    queryClient.invalidateQueries({ queryKey: ["activities"] });
  }

  return (
    <div className="space-y-4">
      <form onSubmit={handleSubmit}>
        <div className="space-y-6">
          <input type="hidden" name="id" id="id" value={id} />
          <div className="space-y-2">
            <Label
              htmlFor="title"
              className="text-teal-medium dark:text-teal-lightest"
            >
              Título
            </Label>
            <Input
              id="title"
              name="title"
              defaultValue={activity.title}
              placeholder="Activity title"
              required
            />
            {errors?.title && (
              <span className="text-xs font-medium text-red-500 dark:text-red-400">
                {errors.title[0]}
              </span>
            )}
          </div>

          <div className="space-y-2">
            <Label
              htmlFor="description"
              className="text-teal-medium dark:text-teal-lightest"
            >
              Descrição
            </Label>
            <Textarea
              id="description"
              name="description"
              defaultValue={activity.description}
              placeholder="Describe the activity..."
            />
            {errors?.description && (
              <span className="text-xs font-medium text-red-500 dark:text-red-400">
                {errors.description[0]}
              </span>
            )}
          </div>

          <div className="space-y-2">
            <Label
              htmlFor="status"
              className="text-teal-medium dark:text-teal-lightest"
            >
              Status
            </Label>
            <Select
              defaultValue={activity.status.toString()}
              onValueChange={updateStatus}
            >
              <SelectTrigger id="status" className="w-full">
                <SelectValue placeholder="Selecione um status" />
              </SelectTrigger>
              <SelectContent>
                {Array.from(ActivityStatusLabel.entries()).map(
                  ([Value, label]) => (
                    <SelectItem key={Value} value={Value.toString()}>
                      {label}
                    </SelectItem>
                  )
                )}
              </SelectContent>
            </Select>
          </div>

          <div className="flex gap-3 justify-end border-t border-teal-lightest/30 dark:border-teal-light/30 pt-6">
            <Button variant="default" type="submit" className="cursor-pointer">
              <Save />
              Save Changes
            </Button>
            <Button
              onClick={() => deleteAct(id)}
              variant="destructive"
              type="button"
              className="cursor-pointer"
            >
              <Trash2 />
              Deletar
            </Button>
          </div>
        </div>
      </form>
    </div>
  );
}
