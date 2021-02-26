import {
  Box,
  Button,
  Checkbox,
  Flex,
  Heading,
  PopoverArrow,
  PopoverContent,
  PopoverHeader,
  PopoverTrigger,
  Skeleton,
  useToast,
} from '@chakra-ui/react'
import { useRouter } from 'next/router'
import React, { useEffect, useState } from 'react'
import {
  Project,
  useProject,
  useProjectCategory,
  useProjectStatuses,
  useProjectTypes,
} from '../../api/hooks/project'
import { FlexCentered } from '../../components/chakra/FlexCentered'
import { TinyEditor } from '../../components/page/Projects/Single/TinyEditor'
import { EventList } from '../../components/ui/common/EventList'
import { useEvents } from '../../api/hooks/event'
import { Linker, LinkType } from '../../components/Linker'
import moment from 'moment'
import produce from 'immer'
import { projectPut } from '../../api/actions/project'
import { InputText, TextType } from '../../components/InputText'
import { SelectText } from '../../components/SelectText'
import { Popover } from '@chakra-ui/popover'
import { CSelect } from '../../components/Forms/CSelect/CSelect'
import { CDayPicker } from '../../components/DayPicker/DayPicker'
import { ReusableModal } from '../../components/ReusableModal/Modal'

const ProjectPage = () => {
  const toast = useToast()
  const { query } = useRouter()

  const [datePicked, setDatePicked] = useState(new Date())
  const [projectType, setProjectType] = useState<string>()
  const [projectCategory, setProjectCategory] = useState<string>()

  const { project, mutate } = useProject(String(query.key))
  const { events } = useEvents()
  const { projectStatuses } = useProjectStatuses()
  const { projectTypes } = useProjectTypes()
  const { projectCategories } = useProjectCategory(projectType)

  useEffect(() => {
    if (project) {
      setProjectType(project.typeDefinitionKey)
      setProjectCategory(project.categoryKey)
    }
  }, [project])

  const saveChanges = async (projectModified: Project) => {
    await mutate(projectModified, false)
    await projectPut(projectModified)
    await mutate()

    toast({
      title: 'Przedmiot został zmodyfikowany pomyślnie',
      status: 'success',
      duration: 5000,
      isClosable: true,
    })
  }

  const onDateChange = async () => {
    const projectModified = {
      ...project,
      deadlineTime: datePicked.toISOString(),
    }

    if (projectModified.deadlineTime !== project?.deadlineTime) {
      await saveChanges(projectModified as Project)
    }
  }

  const onTypeAndCategoryChange = async () => {
    const projectModified = {
      ...project,
      typeDefinitionKey: projectType,
      categoryKey: projectCategory,
    }
    if (projectModified.typeDefinitionKey !== project?.typeDefinitionKey) {
      await saveChanges(projectModified as Project)
    }
  }

  const onProjectModified = async (key: keyof Project, value: string) => {
    const projectModified = produce(project, (draft) => {
      if (draft) {
        // @ts-ignore https://github.com/microsoft/TypeScript/issues/31663
        draft[key] = value
      }
      return draft
    })

    if (projectModified && projectModified !== project) {
      await saveChanges(projectModified)
    }
  }

  const onProjectTypeChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
    setProjectType(e.target.value)
  }

  const onProjectCategoryChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
    setProjectCategory(e.target.value)
  }
  return (
    <Flex flexDir="row" w="100%" h="100%" justifyContent="space-between">
      <Box>
        <Flex
          flexDir="row"
          padding="25px"
          background="white"
          borderRadius="15px"
        >
          <Skeleton
            isLoaded={!!project}
            display="flex"
            alignItems="center"
            flexDir="column"
          >
            {project && (
              <>
                <InputText
                  text={project.name}
                  onTextChanged={onProjectModified}
                  keyModified="name"
                  textType={TextType.Heading}
                  fontSize="4xl"
                />
                b
                <FlexCentered
                  mt="36px"
                  backgroundColor="#dcdaf2"
                  h="60px"
                  w="100%"
                >
                  <Heading color="#271257" fontSize="xl">
                    <Linker
                      type={LinkType.Subjects}
                      typeKey={project?.subjectKey}
                    >
                      {project?.subjectTitle}
                    </Linker>
                  </Heading>
                </FlexCentered>
                <Popover>
                  <PopoverTrigger>
                    <Flex flexDir="row" cursor="pointer">
                      <FlexCentered
                        mt="36px"
                        mr="60px"
                        backgroundColor="#271257"
                        h="60px"
                        w="300px"
                        color="white"
                      >
                        <Heading fontSize="xl">
                          {project?.typeDefinitionName}
                        </Heading>
                      </FlexCentered>
                      <FlexCentered
                        mt="36px"
                        backgroundColor="#271257"
                        h="60px"
                        w="300px"
                      >
                        <Heading color="white" fontSize="xl">
                          {project?.categoryName}
                        </Heading>
                      </FlexCentered>
                    </Flex>
                  </PopoverTrigger>
                  <PopoverContent padding="20px">
                    <PopoverHeader>
                      <PopoverArrow />
                      Wybierz typ oraz kategorię projektu
                    </PopoverHeader>

                    <CSelect
                      defaultValue={project.typeDefinitionKey}
                      name="typeDefinitionKey"
                      selectOptions={projectTypes}
                      onChange={onProjectTypeChange}
                      labelText="Wybierz typ projektu"
                    />
                    <CSelect
                      name="categoryKey"
                      onChange={onProjectCategoryChange}
                      selectOptions={projectCategories}
                      labelText="Wybierz z kategorii"
                    />
                    <Button
                      backgroundColor="#271257"
                      onClick={async () => await onTypeAndCategoryChange()}
                    >
                      Zmień
                    </Button>
                  </PopoverContent>
                </Popover>
              </>
            )}
          </Skeleton>
          <Flex ml="75px" flexDir="column" justifyContent="space-between">
            <FlexCentered
              backgroundColor="#271257"
              h="60px"
              w="300px"
              cursor="pointer"
            >
              <Popover placement="bottom-end">
                <PopoverTrigger>
                  <Heading color="white" fontSize="xl">
                    {moment(project?.deadlineTime).locale('pl').format('LL')}
                  </Heading>
                </PopoverTrigger>
                <PopoverContent w="600px" padding="20px">
                  <PopoverArrow />
                  <PopoverHeader>Wybierz datę dla projektu:</PopoverHeader>
                  <CDayPicker date={datePicked} onDateChange={setDatePicked} />
                  <Button
                    mt="10px"
                    backgroundColor="#271257"
                    onClick={async () => await onDateChange()}
                  >
                    Zmień
                  </Button>
                </PopoverContent>
              </Popover>
            </FlexCentered>

            <FlexCentered>
              <Checkbox></Checkbox>
            </FlexCentered>

            <FlexCentered
              backgroundColor="#271257"
              h="60px"
              w="300px"
              color="white"
              padding="20px"
            >
              {project && (
                <SelectText
                  keyModified="projectStatusKey"
                  selectedKey={project.projectStatusKey}
                  text={project.projectStatusName}
                  textType={TextType.Heading}
                  fontSize="xl"
                  onChange={onProjectModified}
                  options={projectStatuses}
                />
              )}
            </FlexCentered>
          </Flex>
        </Flex>
        <Flex
          flexDir="column"
          backgroundColor="white"
          mt="30px"
          borderRadius="15px"
        >
          <Heading h="80px" display="flex" alignItems="center" ml="25px">
            Notatki
          </Heading>
          <Skeleton
            isLoaded={!!project}
            display="flex"
            alignItems="center"
            w="100%"
          >
            {project && (
              <TinyEditor
                onChange={onProjectModified}
                currentText={project.description}
              />
            )}
          </Skeleton>
        </Flex>
      </Box>
      <Flex ml="30px" w="350px" flexDir="column">
        <EventList
          events={events?.filter((ev) => ev.projectKey === project?.projectKey)}
        />
      </Flex>
    </Flex>
  )
}

export default ProjectPage
