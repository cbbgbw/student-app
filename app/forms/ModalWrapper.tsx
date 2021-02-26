import React, { FC, useContext } from 'react'
import { AddSubject } from './AddSubject'
import { ModalType } from '../types/types'
import { GlobalDataContext } from '../components/Auth/Provider'
import { AddProject } from './AddProject'
import { AddEvent } from './AddEvent'

export const ModalWrapper: FC = () => {
  const { modalType } = useContext(GlobalDataContext)

  switch (modalType) {
    case ModalType.AddSubject:
      return <AddSubject />
    case ModalType.AddProject:
    case ModalType.AddExam:
      return <AddProject />
    case ModalType.AddEvent:
      return <AddEvent />
    default:
      return null
  }
}
