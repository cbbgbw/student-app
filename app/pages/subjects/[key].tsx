import { useSubject } from '../../api/hooks/subject'
import { useRouter } from 'next/router'
import React, { useRef, useState } from 'react'
import { Flex, Grid, GridItem, Text, Textarea } from '@chakra-ui/react'
import { ProjectList } from '../../components/ui/Subjects/ProjectList'
import { SubjectNote } from '../../components/ui/Subjects/Note'
import { useEventsForSubject } from '../../api/hooks/event'
import { EventList } from '../../components/ui/common/EventList'

const SubjectPage = () => {
  const { query } = useRouter()
  const { subject } = useSubject(String(query.key))
  const { events } = useEventsForSubject(String(query.key))

  const [desc, setDesc] = useState(subject?.description)

  return (
    <Grid width="100%" h="100%" gridColumnGap="50px" gridRowGap="20px">
      <GridItem
        borderRadius="12px"
        gridRowStart="1"
        gridRowEnd="2"
        gridColumnStart="1"
        gridColumnEnd="3"
        backgroundColor="white"
        display="flex"
        justifyContent="space-between"
        alignItems="center"
      >
        <Text fontSize="4xl" marginX="30px" marginY="15px" fontStyle="">
          {subject?.name}
        </Text>

        <Text fontSize="2xl" marginX="30px" marginY="15px">
          {subject?.typeDefinitionName}
        </Text>

        <Text
          borderRadius="12px"
          paddingLeft="20px"
          paddingRight="20px"
          fontSize="2xl"
          color="white"
          backgroundColor={subject?.isPassed === true ? '#4CD964' : '#FA0000'}
          marginLeft="20px"
          marginRight="20px"
        >
          {subject?.isPassed === true ? 'zaliczony' : 'niezaliczony'}
        </Text>
      </GridItem>

      <GridItem
        gridColumnStart="1"
        gridColumnEnd="3"
        gridRowStart="2"
        gridRowEnd="4"
        backgroundColor="white"
        borderRadius="12px"
      >
        <Textarea
          height="100%"
          borderRadius="12px"
          placeholder="Opis przedmiotu"
          fontSize="2xl"
          resize="none"
          value={desc}
          onChange={({ target }) => setDesc(target.value)}
          border="transparent"
          css={{
            '&::-webkit-scrollbar': {
              width: '10px',
            },
            '&::-webkit-scrollbar-track': {
              width: '6px',
              background: '#dadada',
              //borderRadius: '24px',
            },
            '&::-webkit-scrollbar-thumb': {
              background: '#271257',
              borderRadius: '24px',
            },
          }}
        />
      </GridItem>
      <GridItem
        gridColumnStart="1"
        gridColumnEnd="3"
        gridRowStart="4"
        gridRowEnd="10"
        h="100%"
        w="100%"
        //   overflow="auto"
        // css={{
        //   '&::-webkit-scrollbar': {
        //     width: '10px',
        //   },
        //   '&::-webkit-scrollbar-track': {
        //     width: '6px',
        //     background: '#ffffff',
        //     borderRadius: '24px',
        //   },
        //   '&::-webkit-scrollbar-thumb': {
        //     background: '#8C8C8C',
        //     borderRadius: '24px',
        //   },
        // }}
      >
        <Flex h="100%" w="100%">
          <ProjectList subjectKey={subject?.subjectKey} />
        </Flex>
      </GridItem>
      <GridItem gridColumnStart="3" gridRowStart="1" gridRowEnd="10" h="100%">
        <EventList events={events} />
      </GridItem>
    </Grid>
  )
}

export default SubjectPage
