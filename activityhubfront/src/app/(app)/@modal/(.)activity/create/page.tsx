import {
  Dialog,
  DialogDescription,
  DialogHeader,
  DialogTitle,
} from "@/components/ui/dialog";
import FormCreateActivity from "../../../_components/activities/create/form-create-activity";
import { InterceptedDialogContent } from "@/components/shared/intercepted-dialog-content";

export default async function Create() {
  return (
    <Dialog defaultOpen>
      <div>
        <InterceptedDialogContent>
          <DialogHeader>
            <DialogTitle>📌 Vamos Criar Novas Atividades</DialogTitle>
            <DialogDescription>
              Adicione uma nova atividade para organizar suas tarefas. Defina um
              título e uma descrição para facilitar o acompanhamento. Você pode
              editar ou atualizar o status depois. 🚀
            </DialogDescription>
          </DialogHeader>
          <div>
            <FormCreateActivity />
          </div>
        </InterceptedDialogContent>
      </div>
    </Dialog>
  );
}
