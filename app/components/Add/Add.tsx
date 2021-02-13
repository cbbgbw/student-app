import { FC } from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faPlus } from '@fortawesome/free-solid-svg-icons'
import { Button, Text } from '@chakra-ui/react'

export interface AddProps {
  name: string
  onClick: () => void
}

export const Add: FC<AddProps> = ({ name, onClick }) => (
  <Button
    h={'140px'}
    w={'140px'}
    d="flex"
    alignItems="flex-start"
    flexDir="column"
    justifyContent="space-around"
    onClick={() => onClick()}
  >
    <Text>
      Dodaj <br />
      {name}
    </Text>
    <FontAwesomeIcon icon={faPlus} size="3x" />
  </Button>
)
