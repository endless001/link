import {Contact} from "types/contact";
import {useHttp} from "hooks/use-http";
import {cleanObject} from "utils";
import {QueryKey, useMutation, useQuery} from "react-query";


export const useGroups = (param?: Partial<Contact>) => {
  const client = useHttp();
  return useQuery<Contact[]>(["projects", cleanObject(param)], async () =>
    (await client)("projects", { data: param })
  );
};

export const useAddGroup =()=> {
  const client = useHttp();

  return useMutation(
    async (params: Partial<Contact>) =>
      (await client)(`tasks`, {
        data: params,
        method: "POST",
      }),
  );
}

export const useDeleteGroup = (queryKey: QueryKey) => {
  const client = useHttp();

  return useMutation(
    async ({ id }: { id: number }) =>
      (await client)(`tasks/${id}`, {
        method: "DELETE",
      })
  );
};

