import {
  Dialog,
  DialogDescription,
  DialogHeader,
  DialogTitle,
} from "@/components/ui/dialog";
import { InterceptedDialogContent } from "@/components/shared/intercepted-dialog-content";
import FormEditActivity from "@/app/(app)/_components/activities/edit/form-edit-activity";
import { getByIdActivity } from "@/http/activities/get-by-id";

export default async function Edit({
  params,
}: {
  params: Promise<{ id: string }>;
}) {
  const { id } = await params;

  const activity = await getByIdActivity(id);

  return (
    <Dialog defaultOpen>
      <div>
        <InterceptedDialogContent className="w-[80%]">
          <DialogHeader>
            <DialogTitle>✏️ Editando a Atividade</DialogTitle>
            <DialogDescription className="flex flex-col gap-3">
              Agora você pode atualizar a atividade para mantê-la organizada e
              em dia! Ajuste o título, refine a descrição e, se necessário,
              modifique o status para refletir o progresso. 📂
              <span>
                Mantenha suas tarefas alinhadas e seu fluxo de trabalho
                eficiente! 🚀
              </span>
            </DialogDescription>
          </DialogHeader>
          <div>
            <FormEditActivity activity={activity} id={id} />
          </div>
        </InterceptedDialogContent>
      </div>
    </Dialog>
  );
}
