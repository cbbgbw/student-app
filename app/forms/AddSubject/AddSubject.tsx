import { useForm } from 'react-hook-form'
import React, { FC, useContext } from 'react'
import { ReusableModal } from '../../components/ReusableModal/Modal'
import { useRouter } from 'next/router'
import { ModalType } from '../../types/types'
import { GlobalDataContext } from '../../components/Auth/Provider'
import { Checkbox, FormLabel, Input } from '@chakra-ui/react'
import { CSelect } from '../../components/Forms/CSelect/CSelect'
import { CTextArea } from '../../components/Forms/CTextarea/CTextArea'
import { useSemesters } from '../../api/hooks/semester'
import { SubjectCreateModel, subjectPost } from '../../api/actions/subject'
import { useSubjects, useSubjectTypes } from '../../api/hooks/subject'

export const AddSubject: FC = () => {
  const router = useRouter()
  const { reFetch } = useSubjects()
  const { currentSemester } = useSemesters()
  const { modalType, setModalType } = useContext(GlobalDataContext)

  const { handleSubmit, register } = useForm<SubjectCreateModel>()

  const { subjectTypes } = useSubjectTypes()

  const onSubjectSubmit = async (data: SubjectCreateModel) => {
    await subjectPost(data, currentSemester?.[0])
      .then(() => setModalType(ModalType.None))
      .then(() => {
        reFetch()
        router.push({
          pathname: '/subjects',
        })
      })
  }

  return (
    <ReusableModal
      isOpen={modalType !== 'None'}
      onClose={() => setModalType(ModalType.None)}
      headerText={{
        title: 'Nowy przedmiot',
        description:
          'Po wpisaniu wymaganych danych przejdziesz do widoku przedmiotu',
      }}
      cancelButtonText="Anuluj"
      acceptButtonText="Utwórz przedmiot"
      onSubmit={handleSubmit(onSubjectSubmit)}
    >
      <FormLabel htmlFor="name">Nazwa przedmiotu</FormLabel>
      <Input name="name" ref={register({ required: true })} />
      <FormLabel htmlFor="typeDefinitionKey">Typ przedmiotu</FormLabel>

      <CSelect
        name="typeDefinitionKey"
        ref={register({ required: true })}
        selectOptions={subjectTypes}
        labelText=""
      />
      <CTextArea name="description" ref={register()} labelText="Opis" />
      <Checkbox name="hasProjectToPass" ref={register()}>
        Chcę utworzyć projekt który jednocześnie jest zaliczeniem przedmiotu
      </Checkbox>
    </ReusableModal>
  )
}
