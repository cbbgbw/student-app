import React, { FC } from 'react'
import { AddSubject } from './AddSubject/AddSubject'
import { useStore } from '../utils/storeProvider'
import { ModalType } from '../types/types'

export const ModalWrapper: FC = () => {
  const { modalType } = useStore()

  switch (modalType) {
    case ModalType.AddSubject:
      return <AddSubject />
    case ModalType.AddProject:
    default:
      return null
  }
}
