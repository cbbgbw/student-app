import React, { FC, useContext } from 'react'
import { AddSubject } from './AddSubject/AddSubject'
import { ModalType } from '../types/types'
import { GlobalDataContext } from '../components/Auth/Provider'
import { AddProject } from './AddProject/AddProject'

export const ModalWrapper: FC = () => {
  const { modalType } = useContext(GlobalDataContext)

  switch (modalType) {
    case ModalType.AddSubject:
      return <AddSubject />
    case ModalType.AddProject:
      return <AddProject />

    default:
      return null
  }
}
