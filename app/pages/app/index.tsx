import React, { FC, useContext } from 'react'

import { EntitiesModal } from '../../types/types'
import { Add } from '../../components/Add/Add'

// import styles from './index.module.scss'
import { Box, Flex, Heading, List, ListItem, Text } from '@chakra-ui/react'
import { GlobalDataContext } from '../../components/Auth/Provider'
import { useProjectCount, useProjects } from '../../api/hooks/project'
import { useEvents } from '../../api/hooks/event'
import { getDateFormatted } from '../../utils/dateUtils'
import { EventList } from '../../components/ui/common/EventList'
import { Linker, LinkType } from '../../components/Linker'
import { SelectSemesterPopover } from '../../components/ui/Dashboard/SelectSemesterPopover'

const Dashboard: FC = () => {
  const { projectsCount } = useProjectCount()
  const { projects } = useProjects()
  const { events } = useEvents()

  const { setModalType } = useContext(GlobalDataContext)

  const generateAddButtons = () =>
    Object.keys(EntitiesModal).map((value) => (
      <Add
        key={value}
        name={value.toLowerCase()}
        onClick={() => {
          setModalType(EntitiesModal[value])
          console.log('log')
        }}
      />
    ))

  const generateIncoming = () =>
    projects &&
    Object.values(projects).map((project) => (
      <Flex
        key={project.projectKey}
        paddingLeft="10px"
        pr="20px"
        mt="20px"
        borderRadius="6px"
        justifyContent="space-between"
        alignItems="center"
        fontSize="2xl"
        border={
          project.typeDefinitionName === 'Projekt'
            ? '2px solid #3B2E61'
            : '2px solid #BBA5E1'
        }
        backgroundColor={
          project.typeDefinitionName === 'Projekt' ? '#3B2E61' : '#BBA5E1'
        }
        color={project.typeDefinitionName === 'Projekt' ? 'white' : '#1D0B47'}
      >
        <Flex marginTop="5px" alignItems="center" w="85%">
          <Text w="100px">{project.typeDefinitionName}</Text>
          <Linker type={LinkType.Projects} typeKey={project.projectKey}>
            <Text ml="20px" w="400px">
              {project.name}
            </Text>
          </Linker>
          <Linker type={LinkType.Subjects} typeKey={project.subjectKey}>
            <Text ml="20px" w="350px">
              {project.subjectTitle}
            </Text>
          </Linker>
        </Flex>
        <Text ml="20px" justifyContent="end" w="15%">
          {getDateFormatted(project.deadlineTime)}
        </Text>
      </Flex>
    ))

  const generateCounters = () =>
    projectsCount?.map((values) => (
      <Flex
        key={values.typeDefinitionKey}
        flexDir="column"
        alignItems="center"
        marginRight="10px"
      >
        <Text fontSize="2xl">
          {values.typeName === 'Projekt' ? 'Projekty' : 'Egzaminy'}
        </Text>
        <Text
          fontSize="2xl"
          borderRadius="12px"
          padding="7px"
          backgroundColor="#E3DDF0"
        >
          {values.countValue}
        </Text>
      </Flex>
    ))

  return (
    <Flex w="100%" direction="row" h="100%">
      <Box width="100%">
        <Flex mt={15} justify="space-between">
          {generateAddButtons()}
        </Flex>

        <Flex
          borderRadius="12px"
          flexDir="column"
          paddingX="20px"
          paddingY="10px"
          backgroundColor="white"
          mt="40px"
          overflow="auto"
          h="75%"
          css={{
            '&::-webkit-scrollbar': {
              width: '10px',
            },
            '&::-webkit-scrollbar-track': {
              width: '6px',
              background: '#dadada',
              // borderRadius: '24px',
            },
            '&::-webkit-scrollbar-thumb': {
              background: '#271257',
              borderRadius: '24px',
            },
          }}
        >
          <Flex justifyContent="space-between" alignItems="center">
            <Heading fontSize="4xl" paddingLeft="10px">
              Nadchodzące
            </Heading>
            <Flex>{generateCounters()}</Flex>
          </Flex>

          <Flex
            // pl="20px"
            pr="20px"
            mt="20px"
            borderBottom="4px solid #3B2E61"
            paddingLeft="10px"
            // borderRadius="6px"
            justifyContent="space-between"
            fontSize="2xl"
          >
            <Flex w="85%">
              <Text w="100px">Typ</Text>
              <Text ml="20px" w="400px">
                Nazwa projektu
              </Text>
              <Text ml="20px" w="350px">
                Przedmiot
              </Text>
            </Flex>

            <Text ml="20px" w="15%">
              Data końcowa
            </Text>
          </Flex>
          {generateIncoming()}
        </Flex>
      </Box>
      <Flex
        justifyContent="space-between"
        flexDir="column"
        alignItems="center"
        marginLeft="20px"
        w="30%"
        h="100%"
      >
        <SelectSemesterPopover />

        <EventList events={events} />
      </Flex>
    </Flex>
  )
}

export default Dashboard
