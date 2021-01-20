import React, { FC } from 'react'
import { AddSubject } from './AddSubject/AddSubject'
import { ModalType } from '../types/types'
import { useModalType } from '../hooks/useModalType'

export const ModalWrapper: FC = () => {
  const { modalType } = useModalType()

  switch (modalType) {
    case ModalType.AddSubject:
      return <AddSubject />
    case ModalType.AddProject:
    default:
      return null
  }
}
