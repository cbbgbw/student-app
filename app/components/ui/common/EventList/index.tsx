import { Flex, Heading, List, ListItem, Text } from '@chakra-ui/react'
import React, { FC } from 'react'
import { ProjectEvent } from '../../../../api/hooks/event'
import moment from 'moment'
import { useProjects } from '../../../../api/hooks/project'
import { Color } from '../../../../consts/colors'
import { Linker, LinkType } from '../../../Linker'

interface Props {
  events: ProjectEvent[] | undefined
}

export const EventList: FC<Props> = ({ events }) => {
  const { getAsKeyValue } = useProjects()
  const projects = getAsKeyValue()

  return (
    <Flex
      h="100%"
      borderRadius="15px"
      display="flex"
      alignItems="center"
      backgroundColor={Color.BlackPurple}
      flexDir="column"
    >
      <Heading mx="40px" mt="36px" color={Color.White}>
        WYDARZENIA
      </Heading>
      <List w="100%" px="20px" mt="20px">
        {events?.map(({ title, setTime, projectKey }) => {
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
                <Text>{projects[projectKey] || 'Błąd'}</Text>
              </Linker>
              <Heading fontSize="2xl">
                {moment(setTime).locale('pl').format('LL')}
              </Heading>
              <Text fontSize="xl">{title}</Text>
            </ListItem>
          )
        })}
      </List>
    </Flex>
  )
}
