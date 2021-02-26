import React, { FC, useContext, useState } from 'react'
import { ReusableModal } from '../../components/ReusableModal/Modal'
import { ModalType } from '../../types/types'
import { GlobalDataContext } from '../../components/Auth/Provider'
import { CDayPicker } from '../../components/DayPicker/DayPicker'
import { useForm } from 'react-hook-form'
import { FormLabel, Input } from '@chakra-ui/react'
import { CTextArea } from '../../components/Forms/CTextarea/CTextArea'
import { SubjectCreateModel } from '../../api/actions/subject'
import { EventFormData, postEvent } from '../../api/actions/event'
import { useProjects } from '../../api/hooks/project'
import { CSelect } from '../../components/Forms/CSelect/CSelect'

export const AddEvent: FC = () => {
  const { handleSubmit, register } = useForm<SubjectCreateModel>()
  const { projects, getAsKeyValue } = useProjects()
  const { modalType, setModalType } = useContext(GlobalDataContext)
  const [datePicked, setDatePicked] = useState(new Date())

  const onEventSubmit = async (data: EventFormData) =>
    await postEvent({ ...data, setTime: datePicked.toISOString() }).then(() =>
      setModalType(ModalType.None),
    )

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
      <FormLabel htmlFor="title">Nazwa wydarzenia</FormLabel>
      <Input name="title" ref={register({ required: true })} />
      <CSelect
        name="projectKey"
        ref={register({ required: true })}
        selectOptions={getAsKeyValue()}
        labelText="Wybierz projekt"
      />
      <CDayPicker date={datePicked} onDateChange={setDatePicked} />
      <CTextArea name="content" ref={register()} labelText="Notatka" />
    </ReusableModal>
  )
}
