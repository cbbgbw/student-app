import { useForm } from "react-hook-form";
import React from "react";
import { Input } from "../../components/Forms/Input/Input";
import { ReusableModal } from "../../components/ReusableModal/Modal";
import { getModalTypeFuncs } from "../../utils/storeUtils";
import { ModalType } from "../ModalWrapper";
import { useStore } from "../../utils/storeProvider";

type Inputs = {
  name: string;
  description: string;
  state: string; //TODO In future enum
};

export const AddSubject = () => {
  const { modalType, setModalType } = useStore(getModalTypeFuncs);

  const { handleSubmit, register } = useForm<Inputs>();

  const onSubmit = (data: unknown) => {
    console.log(data);
  };

  return (
    <ReusableModal
      isOpen={modalType !== "None"}
      onModalLeave={() => setModalType(ModalType.None)}
      headerText={{
        title: "Nowy przedmiot",
        description:
          "Po wpisaniu wymaganych danych przejdziesz do widoku przedmiotu"
      }}
      cancelButtonText={"Anuluj"}
      acceptButtonText={"Utwórz przedmiot"}
    >
      <form onSubmit={handleSubmit(onSubmit)}>
        <Input
          name={"name"}
          ref={register({ required: true })}
          labelText={"Nazwa przedmiotu"}
        />
        <Input
          name={"description"}
          ref={register({ required: true })}
          labelText={"Opis"}
          isMultiline={true}
        />
        <Input
          name={"state"}
          ref={register({ required: true })}
          labelText={"Typ"}
        />

        <style jsx>{`
          form {
            display: flex;
            flex-direction: column;
            padding-top: 40px;
            padding-left: 36px;
          }

          .button {
            width: fit-content;
            padding: 8px;
          }
        `}</style>
      </form>
    </ReusableModal>
  );
};
