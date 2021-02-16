import { Box, Flex, List, Heading } from '@chakra-ui/react'
import { ProjectListItem } from '../ProjectList/ProjectListItem'
import { FC } from 'react'

interface Props {
  name: string
  maxHeight?: string
  maxWidth?: string
}

export const Container: FC<Props> = ({
  name,
  maxHeight,
  maxWidth = 'auto',
  children,
}) => (
  <Box borderRadius="12px" backgroundColor="#bba5e1" overflow="auto">
    <Flex alignItems="center" justifyContent="center" flexDir="column">
      <Heading
        paddingY="10px"
        fontSize="3xl"
        display="flex"
        alignItems="center"
        color="white"
      >
        {name}
      </Heading>
      <Box maxHeight={maxHeight} maxWidth={maxWidth} w="100%" overflow="auto">
        {children}
      </Box>
    </Flex>
  </Box>
)
