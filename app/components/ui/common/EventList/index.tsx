import {
  Flex,
  Heading,
  List,
  ListItem,
  Text,
  Button,
  Tooltip,
} from '@chakra-ui/react'
import React, { FC, useContext } from 'react'
import { ProjectEvent } from '../../../../api/hooks/event'
import moment from 'moment'
import { useProjects } from '../../../../api/hooks/project'
import { Color } from '../../../../consts/colors'
import { Linker, LinkType } from '../../../Linker'
import { ModalType } from '../../../../types/types'
import { GlobalDataContext } from '../../../Auth/Provider'
import { useRouter } from 'next/router'

interface Props {
  events: ProjectEvent[] | undefined
  type?: EventListType
}

export enum EventListType {
  Month,
  Day,
  NineDays,
}

export const EventList: FC<Props> = ({
  events,
  type = EventListType.NineDays,
}) => {
  const { getAsKeyValue } = useProjects()
  const router = useRouter()
  const { setModalType } = useContext(GlobalDataContext)
  const projects = getAsKeyValue()

  return (
    <Flex
      h="100%"
      borderRadius="15px"
      display="flex"
      alignItems="center"
      backgroundColor={Color.BlackPurple}
      flexDir="column"
      // w={router.pathname.includes('/calendar') ? '30%' : undefined}
    >
      {router.pathname.includes('/calendar') && (
        <Button
          backgroundColor="#805AD5"
          w="75%"
          h="55px"
          marginTop="20px"
          fontSize="20px"
          onClick={() => setModalType(ModalType.AddEvent)}
        >
          Dodaj wydarzenie
        </Button>
      )}

      <Heading mx="40px" mt="20px" color={Color.White}>
        WYDARZENIA
      </Heading>
      {type !== EventListType.NineDays && (
        <Text fontSize="24px" color={Color.White}>
          {(type === EventListType.Month && 'Miesiąca') ||
            (type === EventListType.Day && 'Dnia')}
        </Text>
      )}
      <List
        w="100%"
        px="20px"
        mt="20px"
        overflow="auto"
        css={{
          '&::-webkit-scrollbar': {
            width: '10px',
          },
          '&::-webkit-scrollbar-track': {
            width: '6px',
            background: '#ffffff',
            borderRadius: '24px',
          },
          '&::-webkit-scrollbar-thumb': {
            background: '#8C8C8C',
            borderRadius: '24px',
          },
        }}
      >
        {events?.map(({ title, setTime, projectKey, content }) => {
          // @ts-ignore
          return (
            <ListItem
              w="100%"
              key={title}
              borderRadius="15px"
              padding="20px"
              mb="20px"
              backgroundColor={Color.White}
            >
              <Linker type={LinkType.Projects} typeKey={projectKey}>
                <Text>{projects?.[projectKey] || 'Błąd'}</Text>
              </Linker>
              <Heading fontSize="2xl">
                {moment(setTime).locale('pl').format('LL')}
              </Heading>
              <Tooltip
                label={content === null ? '' : content}
                aria-label="A tooltip"
                placement="top"
              >
                <Text fontSize="xl">{title}</Text>
              </Tooltip>
            </ListItem>
          )
        })}
      </List>
    </Flex>
  )
}
