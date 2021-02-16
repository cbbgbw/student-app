import { Flex, Heading, Link, ListItem, Text } from '@chakra-ui/react'
import { FC } from 'react'

interface Props {
  name: string
  deadlineFormatted: string
  category: string
  state: string
  isRequired: boolean
  statusName: string
  onProjectNameClick: () => void
}

export const ProjectListItem: FC<Props> = ({
  name,
  deadlineFormatted,
  category,
  isRequired,
  statusName,
  onProjectNameClick,
}) => (
  <ListItem
    paddingBottom="20px"
    px="20px"
    backgroundColor="white"
    borderRadius="12px"
    marginBottom="20px"
  >
    <Flex
      my="12px"
      minWidth="300px"
      justifyContent="space-between"
      borderRadius="12px"
      alignItems="center"
    >
      <Link onClick={onProjectNameClick}>
        <Heading fontSize="2xl">{name}</Heading>
      </Link>
      <Text mr="24px">{deadlineFormatted}</Text>
    </Flex>

    <Flex
      borderRadius="12px"
      padding="15px"
      backgroundColor="#E4D3EB"
      flexDir="column"
    >
      <Flex width="100%" justifyContent="space-between">
        <Text>{category}</Text>
        <Text
          borderRadius="12px"
          backgroundColor="white"
          paddingLeft="10px"
          paddingRight="10px"
        >
          {statusName}
        </Text>
      </Flex>
      {isRequired && <Text>Wymagany do zdania przedmiotu</Text>}
    </Flex>
  </ListItem>
)
