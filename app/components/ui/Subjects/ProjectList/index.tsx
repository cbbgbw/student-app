import { Flex, Heading, List } from '@chakra-ui/react'
import { ProjectListItem } from './ProjectListItem'
import { useProjectForSubject } from '../../../../api/hooks/project'
import { Container } from '../Container'
import React, { FC } from 'react'
import { Color } from '../../../../consts/colors'

interface Props {
  subjectKey: string | undefined
}

export const ProjectList: FC<Props> = ({ subjectKey }) => {
  const { projects } = useProjectForSubject(subjectKey)

  return (
    <Flex
      h="100%"
      borderRadius="15px"
      display="flex"
      alignItems="center"
      backgroundColor={Color.BlackPurple}
      flexDir="column"
    >
      <Heading mx="40px" mt="20px" color={Color.White}>
        PROJEKTY
      </Heading>

      <List px="20px" w="100%" display="flex" flexDir="column" marginTop="10px">
        {projects?.map((project) => (
          <ProjectListItem key={project.projectKey} project={project} />
        ))}
      </List>
    </Flex>
  )
}
