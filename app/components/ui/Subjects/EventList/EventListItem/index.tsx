import { FC } from 'react'
import { Grid, Text, Heading, GridItem } from '@chakra-ui/react'

interface Props {
  name: string
  date: string
}

export const EventListItem: FC<Props> = ({ date, name }) => {
  return (
    <Grid h="150px" backgroundColor="white" borderRadius="12px" mb="30px">
      <GridItem px="20px" pt="15px">
        <Text fontSize="xl">{date}</Text>
      </GridItem>
      <GridItem display="flex" justifyContent="center">
        <Heading>{name}</Heading>
      </GridItem>
      <GridItem />
    </Grid>
  )
}
