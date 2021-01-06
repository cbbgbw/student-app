import { useForm } from 'react-hook-form'
import React, { FC } from 'react'

import { Input } from '../../components/Forms/Input/Input'
import { ReusableModal } from '../../components/ReusableModal/Modal'
import { getModalTypeFuncs } from '../../utils/storeUtils'
import { useStore } from '../../utils/storeProvider'
import { subjectPost, PostProps } from '../../actions/subject'
import { useRouter } from 'next/router'
import { MultiLineInput } from '../../components/Forms/Input/MultilineInput'
import { ModalType } from '../../types/types'

export const AddSubject: FC = () => {
  const router = useRouter()
  const { modalType, setModalType } = useStore(getModalTypeFuncs)

  const { handleSubmit, register } = useForm<PostProps>()

  const onSubjectSubmit = async (data: PostProps) => {
    subjectPost(data).then(({ data }) => {
      router.push({
        pathname: '/subject/[key]',
        query: {
          key: data.subjectKEY,
        },
      })
    })
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
      <MultiLineInput
        name="description"
        ref={register({ required: true })}
        labelText="Opis"
      />
      {/* <Input */}
      {/*  name="type" */}
      {/*  ref={register(/* { required: true } */}
      {/*  labelText="Typ" */}
      {/*  disabled */}
      {/* /> */}

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
