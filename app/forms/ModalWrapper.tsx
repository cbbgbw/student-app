import React, { FC } from 'react'
import { AddSubject } from './AddSubject/AddSubject'
import { useStore } from '../utils/storeProvider'
import { ModalType } from '../types/types'
import { getModalTypeFuncs } from '../utils/storeUtils'

export const ModalWrapper: FC = () => {
  const { modalType } = useStore(getModalTypeFuncs)

  switch (modalType) {
    case ModalType.AddSubject:
      return <AddSubject />
    case ModalType.AddProject:
    default:
      return null
  }
}
