import FormCreateActivity from "../../_components/activities/create/form-create-activity";

export default function Create() {
  return (
    <div className="container mx-auto p-8">
      <div className="flex flex-col gap-2 text-center sm:text-left">
        <h1>📌 Vamos Criar Novas Atividades</h1>
        <p>
          Adicione uma nova atividade para organizar suas tarefas. Defina um
          título e uma descrição para facilitar o acompanhamento. Você pode
          editar ou atualizar o status depois. 🚀
        </p>
      </div>
      <div>
        <FormCreateActivity />
      </div>
    </div>
  );
}
