import {Contact} from "types/contact";
import {useHttp} from "hooks/use-http";
import {cleanObject} from "utils";
import {QueryKey, useMutation, useQuery} from "react-query";


export const useMessages = (param?: Partial<Contact>) => {
  const client = useHttp();
  return useQuery<Contact[]>(["projects", cleanObject(param)], async () =>
    (await client)("projects", { data: param })
  );
};


export const useDeleteMessage = (queryKey: QueryKey) => {
  const client = useHttp();

  return useMutation(
    async ({ id }: { id: number }) =>
      (await client)(`tasks/${id}`, {
        method: "DELETE",
      })
  );
};
