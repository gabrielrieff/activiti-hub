import { FormEvent, useState, useTransition } from "react";

interface FormState {
  success: boolean;
  message: string | null | string[];
  errors: Record<string, string[]> | null;
}

export function useFormState(
  action: (event: FormData) => Promise<FormState>,
  onSuccess: () => Promise<void> | void,
  onError?: () => Promise<void> | void,
  initialState?: FormState
) {
  const [isPending, startTransition] = useTransition();

  const [formState, setFormState] = useState(
    initialState ?? {
      success: false,
      message: null,
      errors: null,
    }
  );

  async function handleSubmit(event: FormEvent<HTMLFormElement>) {
    event.preventDefault();

    const form = event.currentTarget;
    const data = new FormData(form);

    startTransition(async () => {
      const state = await action(data);

      if (state.success === true && onSuccess) {
        await onSuccess();
      }

      if (state.success === false && onError) {
        await onError();
      }

      setFormState(state);
    });
  }
  return [formState, handleSubmit, isPending] as const;
}
