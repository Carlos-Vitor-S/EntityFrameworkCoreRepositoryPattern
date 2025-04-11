# 💡 Análise de Exemplos com Princípios SOLID

Este repositório contém uma coleção de exemplos que violam os princípios SOLID em C#. Para cada exemplo, é fornecida a explicação do problema, a análise crítica e sugestões de melhoria. É um ótimo material para estudo e prática de design orientado a objetos.

---

## ✅ Objetivo

Aplicar os cinco princípios SOLID através da identificação de violações e propostas de refatoração. Cada exemplo representa um cenário prático com problemas comuns no design de software.

---

## 📚 Exemplos

### 🧩 Exemplo 1 – SRP (Single Responsibility Principle)

```csharp
public class UserService
{
    public void RegisterUser(string username, string email)
    {
        // Lógica de registro
        Console.WriteLine("Usuário registrado.");

        // Enviar e-mail
        Console.WriteLine("Email enviado para " + email);

        // Gravar log
        Console.WriteLine("Usuário registrado em log.");
    }
}
```

**Análise do usuário:**  
O princípio violado aqui é o SRP.  
A classe `UserService` está acumulando responsabilidades que não são suas.  
Registrar o usuário, enviar e-mail e fazer log são responsabilidades diferentes e deveriam estar em classes separadas.

**Resposta gerada:**  
O código viola o Princípio da Responsabilidade Única.  
Cada classe deve ter uma única razão para mudar.  
`UserService` faz mais do que deveria — idealmente, ela apenas registraria o usuário, delegando o envio de e-mail e o log para outras classes especializadas.

---

### 🧩 Exemplo 2 – OCP + SRP (Open/Closed Principle + Single Responsibility Principle)

```csharp
public class Report
{
    public string Title { get; set; }
    public string Content { get; set; }

    public void GeneratePdf()
    {
        Console.WriteLine("Gerando relatório em PDF...");
    }

    public void GenerateExcel()
    {
        Console.WriteLine("Gerando relatório em Excel...");
    }
}
```

**Análise do usuário:**  
A classe não está preparada para extensões futuras.  
Se for necessário adicionar um novo tipo de geração, ela terá que ser modificada, violando o OCP.  
Além disso, mistura a responsabilidade de conter dados e gerar arquivos, quebrando o SRP.

**Resposta gerada:**  
A classe está sujeita a modificação sempre que for necessário adicionar um novo tipo de exportação.  
O ideal seria criar abstrações como `IReportExporter`, com classes específicas para cada formato.

---

### 🧩 Exemplo 3 – LSP (Liskov Substitution Principle)

```csharp
public class Bird
{
    public virtual void Fly()
    {
        Console.WriteLine("Voando...");
    }
}

public class Ostrich : Bird
{
    public override void Fly()
    {
        throw new NotImplementedException("Avestruz não voa!");
    }
}
```

**Análise do usuário:**  
O princípio LSP é violado aqui.  
`Ostrich` não deveria herdar de `Bird`, pois não consegue cumprir o contrato de voo.  
Isso causa uma exceção em tempo de execução.

**Resposta gerada:**  
Se a subclasse não pode ser usada no lugar da superclasse sem causar erros, a hierarquia está incorreta.  
Uma solução seria separar aves voadoras e não voadoras em classes distintas.

---

### 🧩 Exemplo 4 – ISP (Interface Segregation Principle)

```csharp
public interface IWorker
{
    void Work();
    void Eat();
}

public class Robot : IWorker
{
    public void Work()
    {
        Console.WriteLine("Trabalhando...");
    }

    public void Eat()
    {
        throw new NotImplementedException("Robô não come.");
    }
}
```

**Análise do usuário:**  
O código fere o ISP.  
A classe `Robot` é forçada a implementar um método que não faz sentido para ela (`Eat`).  
É melhor segregar a interface em menores.

**Resposta gerada:**  
`IWorker` é muito ampla.  
Interfaces menores e específicas promovem um design mais limpo e flexível.

---

### 🧩 Exemplo 5 – DIP (Dependency Inversion Principle)

```csharp
public class LightBulb
{
    public void TurnOn()
    {
        Console.WriteLine("Lâmpada acesa");
    }

    public void TurnOff()
    {
        Console.WriteLine("Lâmpada apagada");
    }
}

public class Switch
{
    private LightBulb bulb;

    public Switch()
    {
        bulb = new LightBulb();
    }

    public void Operate()
    {
        bulb.TurnOn();
    }
}
```

**Análise do usuário:**  
`Switch` depende diretamente da implementação `LightBulb`, quebrando o DIP.  
O ideal seria utilizar injeção de dependência com base em uma abstração (`IDevice`), reduzindo o acoplamento.

**Resposta gerada:**  
`Switch` deveria depender de uma interface ao invés de uma classe concreta.  
Isso permite inversão de controle, flexibilidade e testabilidade.

---

## 📦 Arquivo PDF

🔗 [Download PDF com os exemplos e explicações](./SOLID_Exercicios_Resolvidos.pdf)

---
