import React, { FC, useContext } from 'react'

import { EntitiesModal } from '../../types/types'
import { Add } from '../../components/Add/Add'

// import styles from './index.module.scss'
import { Box, Flex, List, ListItem, Text } from '@chakra-ui/react'
import { GlobalDataContext } from '../../components/Auth/Provider'
import { useProjectCount, useProjects } from '../../api/hooks/project'
import { useEvents } from '../../api/hooks/event'
import { parseISOString } from '../../utils/dateUtils'

const Dashboard: FC = () => {
  const { projectsCount } = useProjectCount()
  const { projects } = useProjects()
  const { getEventsParsed } = useEvents()
  const events = getEventsParsed()

  const generateEvents = () =>
    events &&
    Object.keys(events).map((key) => (
      <List key={key} as={Flex}>
        <ListItem>
          <Text
            padding="6px"
            color="#1D0B47"
            backgroundColor="#E3DDF0"
            borderRadius="12px"
          >
            {key}
          </Text>
          <List mb="16px">
            {events[key].map((values) => (
              <ListItem
                key={key}
                ml="5px"
                padding="6px"
                color="#1D0B47"
                backgroundColor="#E3DDF0"
                borderRadius="12px"
                as={Text}
                mt="8px"
              >
                {values.title}
              </ListItem>
            ))}
          </List>
        </ListItem>
      </List>
    ))

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

  const getDateFormatted = (deadlineTime: string) => {
    const date = parseISOString(deadlineTime)
    const day = date.getUTCDate()
    const month = date.getUTCMonth() + 1
    const hour = date.getUTCHours()
    const minute = date.getUTCMinutes()
    return `${String(day).length === 1 ? 0 : ''}${day}.${
      String(month).length === 1 ? 0 : ''
    }${month} | ${String(hour).length === 1 ? 0 : ''}${hour}:${
      String(minute).length === 1 ? 0 : ''
    }${minute}`
  }

  const generateIncoming = () =>
    projects &&
    Object.values(projects).map((value) => (
      <Flex
        key={value.projectKey}
        pl="20px"
        pr="20px"
        mt="15px"
        border="2px solid #8c8c8c"
        borderRadius="12px"
        justifyContent="space-between"
      >
        <Flex>
          <Text>{value.typeDefinitionName}</Text>
          <Text ml="20px">{value.name}</Text>
          <Text ml="20px">{value.subjectTitle}</Text>
        </Flex>

        <Text ml="20px">{getDateFormatted(value.deadlineTime)}</Text>
      </Flex>
    ))

  const generateCounters = () =>
    projectsCount?.map((values) => (
      <Flex key={values.typeDefinitionKey} flexDir="column" alignItems="center">
        <Text>{values.typeName}</Text>
        <Text borderRadius="12px" padding="7px" backgroundColor="#E3DDF0">
          {values.countValue}
        </Text>
      </Flex>
    ))

  return (
    <Flex w="100%" direction="row">
      {/* <Flex mt={6} mb={6} mr={20} justifyContent="flex-end"> */}
      {/*  <SelectSemesterPopover /> */}
      {/* </Flex> */}
      <Box width="100%">
        <Flex mt={15} justify="space-between">
          {generateAddButtons()}
        </Flex>

        <Flex
          borderRadius="12px"
          flexDir="column"
          padding="20px"
          backgroundColor="white"
          mt="40px"
        >
          <Text>Nadchodzące</Text>
          {generateIncoming()}
        </Flex>
      </Box>
      <Flex>
        <Flex
          ml="15px"
          flexDir="column"
          borderRadius="12px"
          padding="15px"
          backgroundColor="#3B2E61"
        >
          <Flex
            padding="12px"
            width="200px"
            justifyContent="space-around"
            borderRadius="12px"
            backgroundColor="white"
          >
            {generateCounters()}
          </Flex>
          <Flex
            mt="15px"
            flexDir="column"
            color="#EAE1FA"
            justifyContent="center"
          >
            Wydarzenia:
            {generateEvents()}
          </Flex>
        </Flex>
      </Flex>
    </Flex>
  )
}

export default Dashboard
