import { Button } from "@/components/ui/button";
import { Card, CardContent, CardHeader } from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";

export default function Page() {
  return (
    <div className="space-y-4">
      <form className="text-white space-y-4">
        <Card className="space-y-1">
          <CardHeader>
            <Label htmlFor="title">Nome</Label>
          </CardHeader>
          <CardContent>
            <Input id="title" name="title" type="text" />
          </CardContent>
        </Card>

        <Button className="w-full">Salvar</Button>
      </form>

      <div className="space-y-4 bg-red-300 px-3 py-4 rounded-2xl">
        <h3 className="font-medium text-red-950">Zona de perigo</h3>
        <p className="text-sm text-white">
          Depois de excluir sua conta, não há como voltar atrás. Por favor, seja
          certo.
        </p>
        <Button variant="destructive">Deletar conta</Button>
      </div>
    </div>
  );
}
