import React, { FC } from "react";
import { AddSubject } from "./AddSubject/AddSubject";
import { useStore } from "../utils/storeProvider";

export enum ModalType {
  None = "None",
  AddSubject = "AddSubject",
  AddProject = "AddProject"
}

export const ModalWrapper: FC = () => {
  const { modalType } = useStore();

  switch (modalType) {
    case ModalType.AddSubject:
      return <AddSubject />;
    case ModalType.AddProject:
    default:
      return null;
  }
};
