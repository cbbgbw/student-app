import {
  ModalBody,
  ModalCloseButton,
  ModalContent,
  ModalFooter,
  ModalHeader,
  ModalOverlay,
  Button,
  Modal,
} from '@chakra-ui/react'
import React, { FC } from 'react'

interface ReusableModalProps {
  isOpen: boolean
  children: any
  headerText: Header
  onClose: () => void
  onSubmit: () => void
  acceptButtonText: string
  cancelButtonText: string
}

interface Header {
  title: string
  description: string
}

export const ReusableModal: FC<ReusableModalProps> = ({
  isOpen,
  children,
  onSubmit,
  headerText: { description, title },
  onClose,
  cancelButtonText,
  acceptButtonText,
}) => (
  <Modal scrollBehavior="inside" size="xl" isOpen={isOpen} onClose={onClose}>
    <ModalOverlay />
    <ModalContent>
      <ModalHeader>{title}</ModalHeader>
      <ModalCloseButton />
      <ModalBody>{children}</ModalBody>
      <ModalFooter d="flex" alignItems="flex-end">
        <Button onClick={onClose}>{cancelButtonText}</Button>
        <Button ml={5} onClick={onSubmit}>
          {acceptButtonText}
        </Button>
      </ModalFooter>
    </ModalContent>
  </Modal>
)
