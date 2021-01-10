import { useForm } from 'react-hook-form'
import React, { FC } from 'react'

import { Input } from '../../components/Forms/Input/Input'
import { ReusableModal } from '../../components/ReusableModal/Modal'
import { getModalTypeFuncs } from '../../utils/storeUtils'
import { useStore } from '../../utils/storeProvider'
import { PostProps, subjectPost, useSubjectTypes } from '../../actions/subject'
import { useRouter } from 'next/router'
import { MultiLineInput } from '../../components/Forms/Input/MultilineInput'
import { ModalType } from '../../types/types'
import { Select } from '../../components/Forms/Select/Select'

export const AddSubject: FC = () => {
  const router = useRouter()
  const { modalType, setModalType } = useStore(getModalTypeFuncs)

  const { handleSubmit, register } = useForm<PostProps>()

  const { subjectTypes } = useSubjectTypes()

  const onSubjectSubmit = async (data: PostProps) => {
    subjectPost(data)
      .then(({ data }) => {
        router.push({
          pathname: '/subjects/[key]',
          query: {
            key: data.subjectKEY,
          },
        })
      })
      .then(() => setModalType(ModalType.None))
  }

  return (
    <ReusableModal
      isOpen={modalType !== 'None'}
      onModalLeave={() => setModalType(ModalType.None)}
      headerText={{
        title: 'Nowy przedmiot',
        description:
          'Po wpisaniu wymaganych danych przejdziesz do widoku przedmiotu',
      }}
      cancelButtonText="Anuluj"
      acceptButtonText="Utwórz przedmiot"
      onSubmit={handleSubmit(onSubjectSubmit)}
    >
      <Input
        name="name"
        ref={register({ required: true })}
        labelText="Nazwa przedmiotu"
      />

      <Select
        name="typeDefinitionKey"
        ref={register({ required: true })}
        labelText="Typ przedmiotu"
        selectOptions={subjectTypes}
      />

      <MultiLineInput
        name="description"
        ref={register()}
        labelText="Opis"
      />

      <Input
        name="hasProjectToPass"
        type="checkbox"
        ref={register()}
        labelText="Chcę utworzyć projekt który jednocześnie jest zaliczeniem przedmiotu"
      />

      <style jsx>{`
        .button {
          width: fit-content;
          padding: 8px;
        }
      `}</style>
    </ReusableModal>
  )
}

/* TODO
  Dodać walidację na:
  puste pola
  wymagane pola

  Dodać obsługę typu kiedy będzie wspierany
 */
