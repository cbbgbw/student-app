import { useForm } from 'react-hook-form'
import React, { FC, useContext } from 'react'
import { ReusableModal } from '../../components/ReusableModal/Modal'
import { PostProps, subjectPost, useSubjectTypes } from '../../actions/subject'
import { useRouter } from 'next/router'
import { ModalType } from '../../types/types'
import { GlobalDataContext } from '../../components/Auth/Provider'
import { Checkbox, FormLabel, Input } from '@chakra-ui/react'
import { CSelect } from '../../components/Forms/CSelect/CSelect'
import { CTextArea } from '../../components/Forms/CTextarea/CTextArea'
import { useUserSemesters } from '../../actions/user/useUserSemesters'

export const AddSubject: FC = () => {
  const { currentSemester } = useUserSemesters()
  const router = useRouter()
  const { modalType, setModalType } = useContext(GlobalDataContext)

  const { handleSubmit, register } = useForm<PostProps>()

  const { subjectTypes } = useSubjectTypes()

  const onSubjectSubmit = async (data: PostProps) => {
    await subjectPost(data, currentSemester?.[0])
      .then(() => setModalType(ModalType.None))
      .then(() =>
        router.push({
          pathname: '/subjects',
        }),
      )
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

/* TODO
  Dodać walidację na:
  puste pola
  wymagane pola */
