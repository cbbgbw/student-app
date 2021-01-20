import { ModalType } from '../types/types'
import { useState } from 'react'

export const useModalType = () => {
  const [modalType, setModalType] = useState(ModalType.None)

  return {
    modalType,
    setModalType,
  }
}
