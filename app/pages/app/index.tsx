import React, { FC, useContext } from 'react'

import { EntitiesModal } from '../../types/types'
import { Add } from '../../components/Add/Add'

// import styles from './index.module.scss'
import { Box, Flex, Heading, List, ListItem, Text } from '@chakra-ui/react'
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
            fontSize="2xl"
            w="100px"
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
    console.log(deadlineTime)
    const date = new Date(deadlineTime)
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
        paddingLeft="10px"
        pr="20px"
        mt="20px"
        borderRadius="6px"
        justifyContent="space-between"
        alignItems="center"
        fontSize="2xl"
        border={
          value.typeDefinitionName === 'Projekt'
            ? '2px solid #3B2E61'
            : '2px solid #BBA5E1'
        }
        backgroundColor={
          value.typeDefinitionName === 'Projekt' ? '#3B2E61' : '#BBA5E1'
        }
        color={value.typeDefinitionName === 'Projekt' ? 'white' : '#1D0B47'}
      >
        <Flex marginTop="5px" alignItems="center" w="85%">
          <Text w="150px">{value.typeDefinitionName}</Text>
          <Text ml="20px" w="400px">
            {value.name}
          </Text>
          <Text ml="20px" w="350px">
            {value.subjectTitle}
          </Text>
        </Flex>
        <Text ml="20px" justifyContent="end" w="15%">
          {getDateFormatted(value.deadlineTime)}
        </Text>
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
    <Flex w="100%" direction="row" h="100%">
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
              borderRadius: '24px',
            },
            '&::-webkit-scrollbar-thumb': {
              background: '#271257',
              borderRadius: '24px',
            },
          }}
        >
          <Heading fontSize="4xl" paddingLeft="10px">
            Nadchodzące
          </Heading>

          <Flex
            //pl="20px"
            pr="20px"
            mt="20px"
            borderBottom="4px solid #7b7b7b"
            paddingLeft="10px"
            //borderRadius="6px"
            justifyContent="space-between"
            fontSize="2xl"
          >
            <Flex w="85%">
              <Text w="150px">Typ</Text>
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
            width="250px"
            justifyContent="space-around"
            borderRadius="12px"
            backgroundColor="white"
            fontSize="2xl"
          >
            {generateCounters()}
          </Flex>
          <Flex
            mt="15px"
            flexDir="column"
            color="#EAE1FA"
            justifyContent="center"
          >
            <Heading fontSize="4xl" textAlign="center" marginY="20px">
              Wydarzenia
            </Heading>
            {generateEvents()}
          </Flex>
        </Flex>
      </Flex>
    </Flex>
  )
}

export default Dashboard
