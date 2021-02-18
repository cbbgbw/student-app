import { useSubject } from '../../api/hooks/subject'
import { useRouter } from 'next/router'
import React, { useRef, useState } from 'react'
import { Grid, GridItem, Text, Textarea } from '@chakra-ui/react'
import { ProjectList } from '../../components/ui/Subjects/ProjectList'
import { SubjectNote } from '../../components/ui/Subjects/Note'
import { EventList } from '../../components/ui/Subjects/EventList'
import { Head } from 'next/document'

const SubjectPage = () => {
  const { query } = useRouter()
  const { subject } = useSubject(String(query.key))

  const [desc, setDesc] = useState(subject?.description)

  return (
    <Grid
      width="100%"
      h="100%"
      gridColumnGap="50px"
      gridTemplateColumns="3"
      gridTemplateRows="8"
      gridRowGap="20px"
    >
      <GridItem
        borderRadius="12px"
        gridRowStart="1"
        rowSpan={1}
        colSpan={1}
        backgroundColor="white"
        display="flex"
        justifyContent="space-between"
        alignItems="center"
      >
        <Text fontSize="3xl" marginX="30px" marginY="15px">
          {subject?.name}
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

      <GridItem gridColumnStart="1" backgroundColor="white" borderRadius="12px">
        <Textarea
          height="100%"
          borderRadius="12px"
          placeholder="Opis przedmiotu"
          resize="none"
          value={desc}
          onChange={({ target }) => setDesc(target.value)}
          border="transparent"
        />
      </GridItem>
      <GridItem gridColumnStart="1">
        <ProjectList />
      </GridItem>
      {/* <GridItem gridColumnStart="2" gridRowStart="2">
        <SubjectNote />
      </GridItem>*/}
      <GridItem gridColumnStart="2" gridRowStart="2">
        <EventList subjectKey={String(query.key)} />
      </GridItem>
    </Grid>
  )
}

export default SubjectPage
