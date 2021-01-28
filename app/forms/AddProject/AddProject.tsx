import React, { FC, useContext, useEffect, useState } from 'react'
import { ReusableModal } from '../../components/ReusableModal/Modal'
import { GlobalDataContext } from '../../components/Auth/Provider'
import { ModalType } from '../../types/types'
import { useForm } from 'react-hook-form'
import { PostProps, useSubjectsBySemester } from '../../actions/subject'
import {
  useProjectTypes,
  useProjectCategory,
  useProjectStatuses,
  postProject,
  ProjectFormData,
} from '../../actions/project'
import { CSelect } from '../../components/Forms/CSelect/CSelect'
import { useUserSemesters } from '../../actions/user/useUserSemesters'
import { Checkbox, FormLabel, Input } from '@chakra-ui/react'
import { CTextArea } from '../../components/Forms/CTextarea/CTextArea'
import 'react-day-picker/lib/style.css'
import { CDayPicker } from '../../components/DayPicker/DayPicker'
import { useRouter } from 'next/router'

export const AddProject: FC = () => {
  const { push } = useRouter()
  const { currentSemester } = useUserSemesters()
  const { projectTypes } = useProjectTypes()
  const { projectStatuses } = useProjectStatuses()
  const [projectType, setProjectType] = useState<string>()
  const { projectCategories } = useProjectCategory(projectType)
  const { getAsKeyValue } = useSubjectsBySemester(currentSemester?.[0])
  const { handleSubmit, register } = useForm<PostProps>()
  const { modalType, setModalType } = useContext(GlobalDataContext)
  const [datePicked, setDatePicked] = useState(new Date())

  const onProjectCategoryChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
    setProjectType(e.target.value)
  }

  const onSubjectSubmit = async (data: ProjectFormData) => {
    await postProject({
      ...data,
      deadlineTime: datePicked,
    }).then(() => push('/projects'))
  }
  return (
    <ReusableModal
      isOpen={modalType !== ModalType.None}
      headerText={{
        title: 'Nowy projekt',
        description:
          'Po wpisaniu wymaganych danych przejdziesz do widoku przedmiotu',
      }}
      onClose={() => setModalType(ModalType.None)}
      onSubmit={handleSubmit(onSubjectSubmit)}
      acceptButtonText="Dodaj projekt"
      cancelButtonText="Anuluj"
    >
      <FormLabel htmlFor="projectName">Nazwa projektu</FormLabel>
      <Input
        marginBottom={15}
        id="projectName"
        name="name"
        ref={register({ required: true })}
      />
      <CSelect
        name="subjectKey"
        ref={register({ required: true })}
        selectOptions={getAsKeyValue()}
        labelText="Wybierz przedmiot projektu"
      />
      <CSelect
        name="typeDefinitionKey"
        ref={register({ required: true })}
        selectOptions={projectTypes}
        onChange={onProjectCategoryChange}
        labelText="Wybierz typ projektu"
      />
      <CSelect
        name="categoryKey"
        ref={register({ required: true })}
        selectOptions={projectCategories}
        labelText="Wybierz z kategorii"
      />
      <CSelect
        name="projectStatusKey"
        ref={register({ required: true })}
        selectOptions={projectStatuses}
        labelText="Jaki jest status twojego projektu?"
      />
      <CTextArea name="description" ref={register()} labelText="Opis" />
      <Checkbox colorScheme="red" name="hasProjectToPass" ref={register()}>
        Projekt niezbędny dla zaliczenia
      </Checkbox>
      <CDayPicker date={datePicked} onDateChange={setDatePicked} />
    </ReusableModal>
  )
}
