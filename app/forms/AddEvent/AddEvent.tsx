import React, { FC, useContext, useState } from 'react'
import { ReusableModal } from '../../components/ReusableModal/Modal'
import { ModalType } from '../../types/types'
import { GlobalDataContext } from '../../components/Auth/Provider'
import { postProject, ProjectFormData } from '../../actions/project'
import { CDayPicker } from '../../components/DayPicker/DayPicker'
import { useForm } from 'react-hook-form'
import { PostProps } from '../../actions/subject'
import { FormLabel, Input } from '@chakra-ui/react'
import { CTextArea } from '../../components/Forms/CTextarea/CTextArea'

export const AddEvent: FC = () => {
  const { handleSubmit, register } = useForm<PostProps>()
  const { modalType, setModalType } = useContext(GlobalDataContext)
  const [datePicked, setDatePicked] = useState(new Date())

  const onEventSubmit = async (data: ProjectFormData) => {
    console.log(data)
  }

  return (
    <ReusableModal
      isOpen={modalType !== ModalType.None}
      headerText={{
        title: 'Nowe wydarzenie',
        description:
          'Po wpisaniu wymaganych danych przejdziesz do widoku przedmiotu',
      }}
      onClose={() => setModalType(ModalType.None)}
      onSubmit={handleSubmit(onEventSubmit)}
      acceptButtonText="Dodaj wydarzenie"
      cancelButtonText="Anuluj"
    >
      <CDayPicker date={datePicked} onDateChange={setDatePicked} />
      <FormLabel htmlFor="name">Nazwa wydarzenia</FormLabel>
      <Input name="name" ref={register({ required: true })} />
      <CTextArea name="description" ref={register()} labelText="Notatka" />
    </ReusableModal>
  )
}
